using CleanArchitectureTemplate.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Infrastructure.Services
{
    internal class DateTimeService : IDateTime
    {
        public long TimeStampNow => DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        public DateTime DateTimeNow => DateTime.UtcNow;
    }
}
