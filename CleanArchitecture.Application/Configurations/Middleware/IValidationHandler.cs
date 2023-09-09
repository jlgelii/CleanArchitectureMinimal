using CleanArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Configurations.Middleware
{
    public interface IValidationHandler { }
    public interface IValidationHandler<T> : IValidationHandler
    {
        Task<ValidationResults> Validate(T request);
    }
}
