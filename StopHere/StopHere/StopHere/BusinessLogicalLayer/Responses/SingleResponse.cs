using BusinessLogicalLayer.Responses;
using FluentValidation.Results;
using System;

namespace BusinessLogicalLayer
{
    public class SingleResponse<T> : Response
    {
        public T Item { get; set; }
    }
}
