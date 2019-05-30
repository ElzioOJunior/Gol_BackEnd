using GOL.Commom.Notification;
using GOL.Commom.Publisher;
using GOL.Database.Context;
using GOL.Database.Repositories;
using GOL.Database.UnitOfWork;
using GOL.Domain.Commands;
using GOL.Domain.Events;
using GOL.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GOL.Cross.IoC
{
    public class DependencyInjectRegistration
    {
        public static void Register(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Publisher 
            services.AddScoped<IPublisher, Publisher>();

            //Repository
            services.AddScoped<IAirplaneRepository, AirplaneRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Context
            services.AddDbContext<GolContext>(opt => opt.UseInMemoryDatabase("golDatabase", null));

            //Commands
            //services.AddScoped<IRequestHandler<NewAirplaneCommand, Unit>, NewAirplaneCommandHandler>();
            services.AddTransient<NewAirplaneCommandHandler, NewAirplaneCommandHandler>();
            services.AddTransient<UpdateAirplaneCommandHandler, UpdateAirplaneCommandHandler>();

            //Events
            services.AddScoped<INotificationHandler<NewAirplaneEvent>, NewAirplaneEventHandler>();
            services.AddScoped<DomainNotificationHandler>();

        }
    }
}
