using AnimalShelter.Api.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace AnimalShelter.Api.HealthChecks
{
    public static class MySqlHealthCheckBuilderExtension
    {
        private const string NAME = "mysql";

        public static IHealthChecksBuilder AddMySql(this IHealthChecksBuilder builder,
            string connectionString,
            int retryCount,
            int delayOnFailure,
            string? name = default,
            HealthStatus? failureStatus = default,
            IEnumerable<string>? tags = default,
            TimeSpan? timeout = default)
        {
            return builder.Add(new HealthCheckRegistration(
                name ?? NAME,
                sp => new MySqlHealthCheck(connectionString, retryCount, delayOnFailure),
                failureStatus,
                tags,
                timeout));
        }

    }
}

