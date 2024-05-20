using System;

namespace Legion{

    public class LoginEventCenter {

        public LoginEventCenter() { }

        public Action OnLoginHandle;
        public void Login() {
            OnLoginHandle?.Invoke();
        }

        public void Clear() {
            OnLoginHandle = null;
        }

    }

}