using System;

namespace VehiclesCrud.Exceptions
{
    // We could always improve these exceptions, move the error message somewhere else, etc
    public class EntityNotFoundException : Exception
    {
        private static readonly string _message = "Entity not found";
        
        public EntityNotFoundException() : base(_message)
        {
        }
    }
}
