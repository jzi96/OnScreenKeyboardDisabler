using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zieschang.net.Projects.OnScreenKeyboardDisabler.Native.Model;

namespace zieschang.net.Projects.OnScreenKeyboardDisabler.Native.ViewModel
{
    public class KeyboardServiceViewModel : PropertyChangedViewModelBase<KeyboardServiceModel>
    {
        private System.ServiceProcess.ServiceController ctrl;
        private System.Threading.Timer _timer;
        private const string ServiceName = "TabletInputService";
        public KeyboardServiceViewModel()
            : base(new KeyboardServiceModel())
        {
            ctrl = new System.ServiceProcess.ServiceController(ServiceName);
            _timer = new System.Threading.Timer(x => LoadServiceState(), null, 1000, 2500);
            LoadServiceState();
        }

        private void LoadServiceState()
        {
            ctrl.Refresh();
            this.Status = ctrl.Status;
        }
        public System.ServiceProcess.ServiceControllerStatus Status
        {
            get { return (System.ServiceProcess.ServiceControllerStatus)this.Model.ServiceStatus; }
            private set
            {
                if (this.Model.ServiceStatus == (int)value) return;
                this.Model.ServiceStatus = (int)value;
                OnPropertyChanged(() => this.Status);
            }
        }

        private string _messages;

        public string Messages
        {
            get { return _messages; }
            set {
                if (_messages == value) return;
                _messages = value;
                OnPropertyChanged(() => Messages);
            }
        }

        public void ChangeServiceState()
        {
            var state= this.Status ;
            this.Messages = string.Empty;
            try
            {
                if (state == System.ServiceProcess.ServiceControllerStatus.Running)
                    ctrl.Stop();
                if (state == System.ServiceProcess.ServiceControllerStatus.Stopped)
                    ctrl.Start();
                if (state == System.ServiceProcess.ServiceControllerStatus.Paused)
                    ctrl.Continue();
            }
            catch (Exception ex)
            {
                this.Messages = string.Format("Looks like we do not have access to manage the service '{0}'. Please make usre granting access to '{0}'. Error: {1}", ctrl.DisplayName, ex.Message);
            }
        }
    }
}
