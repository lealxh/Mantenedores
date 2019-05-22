using System;

namespace MantenedoresPerfilCliente.BFF.Dtos
{
    public class Payload
    {
        public string publicKey { get; set; }
        public string idKey { get; set; }
    }
    public class UsersGetResponseDTO
    {
        public int codigo { get; set; }
        public String mensaje { get; set; }
        public Payload payload { get; set; }

    }
}
