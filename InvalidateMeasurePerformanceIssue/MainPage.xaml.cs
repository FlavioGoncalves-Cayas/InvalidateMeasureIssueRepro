﻿namespace InvalidateMeasurePerformanceIssue;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void Button_OnClicked(object? sender, EventArgs e)
    {
        BindingContext = new MainPageViewModel();
    }
}