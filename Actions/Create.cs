using System;
using System.Collections.Generic;
using MediatR;
using Example.Models;


namespace Example.Actions
{
    public class Create
    {
        public class Response
        {
            private List<string> message;
        }
        public class Request : IRequest<Response>
        {
            public DirectoryObject requestBody;
        }
    }
}