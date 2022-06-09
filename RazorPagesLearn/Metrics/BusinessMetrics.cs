using App.Metrics;
using App.Metrics.Counter;

namespace RazorPagesLearn.Metrics
{
    public static class BusinessMetrics
    {
        public static CounterOptions CounterAddButton => new()
        {
            Context = "AddButton",
            Name = "CounterAddButton",
            MeasurementUnit = Unit.Calls,
            Tags = new MetricTags(new[] { "microservice1" }, new [] {"NumberOne"})
        };
    }
}
