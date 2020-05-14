using MediatR;

namespace Example.Models
{
    public class Request : IRequest<Response>
    {
        public DirectoryObject requestBody;
    }
}
    