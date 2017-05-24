namespace CQRS_MediatR.Domain.ValueObjects
{
    public class Email
    {
        private readonly string _email;
        public Email(string email)
        {
            this._email = email;
            //Cálculo mágico para validar EMAIL....
        }

        public override string ToString()
            => this._email;
    }
}
