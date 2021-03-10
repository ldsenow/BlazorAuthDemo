# BlazorAuthDemo

When user enters into a page which auth is required, the RemoteAuthenticationStateProvider will call FakeAuthenticationStateService and return the user identity.

Then navigate to an anonymos page which auth is not required.

After that, hit the "Back to home" link and navigate back to home page which auth is required.

You will see "Not Authorized" content appear before the FakeAuthenticationStateService returns the state. Also you can check the console logs as well.
