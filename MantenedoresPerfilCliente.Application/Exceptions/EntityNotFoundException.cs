using System;

namespace MantenedoresPerfilCliente.Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string name, string Id) : base("Entity not found " + name + ": " + Id)
        {

        }
    }
}
