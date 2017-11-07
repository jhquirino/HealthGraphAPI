# HealthGraphAPI
[Runkeeper (HealthGraph) API REST](https://runkeeper.com/developer/healthgraph) client in [.NET Core 2.0](https://dotnet.github.io/).

**NOTE:** The current project is in development phase, so it is not fully functional. _November 2017_

## Download/Install

Currently, only the source code is available for download from this [repository](https://github.com/yorchideas/HealthGraphAPI).

```git clone https://github.com/yorchideas/HealthGraphAPI.git```

_**In the future**, this can be installed using [NuGet](https://www.nuget.org), by running the following command in the Package Manager Console:_
```PM> Install-Package HealthGraphAPI```


## Getting started

1. Ensure you already registered your application in the [Runkeeper Partner Portal](https://runkeeper.com/partner/applications).
2. Ensure your project references the `HealthGraphAPI`.
4. [Perform authorization/authentication flow](https://runkeeper.com/developer/healthgraph/registration-authorization) to request the user to allow access to its Runkeeper information.
```csharp
using HealthGraphAPI;

namespace HealthGraphAPI.Examples
{
    public class HealthGraphAPIAuthExample
    {
        private readonly HealthGraphAuth auth;
        private readonly HealthGraphClient client;
        private HealthGraphToken token;
        public HealthGraphAPIAuthExample()
        {
            auth = new HealthGraphAuth
            {
                ClientID = "<<your application client_id>>",
                ClientSecret = "<<your application client_secret>>",
                RedirectUri = new Uri("<<your application redirect_uri>>")
            };
            client = new HealthGraphClient(auth);
        }
        private void PerformAuthFlow()
        {
            var authorizeUri = client.BuildAuthorizeUri();
            // TODO: Use a WebBrowser to navigate the URL retrieved in authorizeUri, it can be done manually or by using any WebBrowser control in any supported client-platform (WinForms, WPF, UWP, Xamarin), sign-in to your Runkeeper account and allow the application to access, when finished, the WebBrowser will redirect to the RedirectUri especified, copy the URL and paste in the next part
            var redirectUri = new Uri("<<paste here the URL redirected from WebBrowser>>");
            var result = client.HandleAuthorization(redirectUri); // TODO: When running in a WebBrowser control, use the 'OnNavigation' event (accordingly to the control)
            if (result.Status = HealthGraphAuthStatus.Auhtorized && client.Token != null)
            {
                // TODO: Authorization/authentication flow was successful, now you can store the client.Token values, to use in futher examples
                token = client.Token;
            }
            else
            {
                // TODO: Handle error
            }
        }
    }
}
```

## Build

**__TODO__**

## Test

**__TODO__**