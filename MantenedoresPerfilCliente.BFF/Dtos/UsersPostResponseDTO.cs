using System;

namespace MantenedoresPerfilCliente.BFF.Dtos
{
    public class PayloadPost
    {
        public string jwt { get; set; }

    }

    public class UsersPostResponseDTO
    {
        public int Codigo { get; set; }
        public String Message { get; set; }
        public PayloadPost Payload { get; set; }
        public String Perfiles  { get; set; }
    }
}
