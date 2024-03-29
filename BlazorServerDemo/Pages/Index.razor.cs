﻿using BlazorServerDemo.Shared.Components;
using BlazorServerDemo.Shared.Components.Navigation;
using Microsoft.AspNetCore.Components;

namespace BlazorServerDemo.Pages;

public partial class Index
{
    [CascadingParameter]
    private MyPageLock? UnsavedChanges { get; set; }

    private void EnterEditMode()
    {
        UnsavedChanges?.SetUnSavedChanges(true);
    }
    
    [Parameter]
    public string? ErrorMessage { get; set; }
    

    public void SetErrorMessage(string errorMessage)
    {
        ErrorMessage = errorMessage;
        StateHasChanged();
    }

    private void ThrowError()
    {
        throw new NotImplementedException();
    }
}