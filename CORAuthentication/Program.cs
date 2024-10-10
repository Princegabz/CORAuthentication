namespace CORAuthentication
{
    class Program
    {
        static void Main(string[] args) 
        {
            AuthenticationBase P = new Password();
            AuthenticationBase OTP = new OneTimePin();
            AuthenticationBase B = new Biometric();

            P.SetSuccessor(OTP);
            OTP.SetSuccessor(B);

            string? Result = null;

            P.Authenticate("Biometric", Result);
            Console.WriteLine(Result);
        }
        public abstract class AuthenticationBase 
        {
            protected AuthenticationBase _Successor;

            public abstract void Authenticate(string Type, string Result);

            public void SetSuccessor(AuthenticationBase Successor)
            {
                _Successor = Successor;
            }
        }

        public class Password : AuthenticationBase
        {
            public override void Authenticate(string Type, string Result)
            {
                if (Type == "Password") 
                {
                    Console.WriteLine("Password has been Authenticated");
                }
                else
                {
                    Console.WriteLine("Password has Passed Authentication to next Authenticator");
                    _Successor.Authenticate(Type, Result);
                }
            }
        }
        public class OneTimePin : AuthenticationBase
        {
            public override void Authenticate(string Type, string Result)
            {
                if (Type == "OneTimePin")
                {
                    Console.WriteLine("OneTimePin has been Authenticated");
                }
                else
                {
                    Console.WriteLine("OneTimePin has Passed Authentication to next Authenticator");
                    _Successor.Authenticate(Type, Result);
                }
            }
        }
        public class Biometric : AuthenticationBase
        {
            public override void Authenticate(string Type, string Result)
            {
                if (Type == "Biometric")
                {
                    Console.WriteLine("Biometric has been Authenticated");
                }
                else
                {
                    Console.WriteLine("Biometric has Passed Authentication to next Authenticator");
                    _Successor.Authenticate(Type, Result);
                }
            }
        }
    }
}
