using System.Diagnostics;

namespace InvalidateMeasurePerformanceIssue;

public class MyGrid : Grid
{
    protected override Size MeasureOverride(double widthConstraint, double heightConstraint)
    {
        Debug.WriteLine($"Measure called {DateTime.Now:O}");
        return base.MeasureOverride(widthConstraint, heightConstraint);
    }
}