using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Spotify.CrossCutting.ValidationBehavior;

namespace Spotify.Infra.CrossCutting.Ioc
{
    public static class MediatorInjection
    {
        public static void AddMediator(this IServiceCollection services)
        {
            const string applicationAssemblyName = "Spotify.Domain";
            var assembly = AppDomain.CurrentDomain.Load(applicationAssemblyName);

            AssemblyScanner
                .FindValidatorsInAssembly(assembly)
                .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddMediatR(assembly);
        }
    }
}