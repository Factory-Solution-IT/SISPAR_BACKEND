namespace Sispar.Infra.ExternalServices
{
    public class AddressModel
    {
        public AddressModel(string zipCode, string address, string complement, 
            string neighborhood, string city, string state)
        {
            ZipCode = zipCode;
            Address = address;
            Complement = complement;
            Neighborhood = neighborhood;
            City = city;
            State = state;
        }

        public string ZipCode { get; private set; }
        public string Address { get; private set; }
        public string Complement { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }

    }
}