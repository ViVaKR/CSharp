# Secrets

```bash
dotnet user-secrets init
dotnet user-secrets set "Utility:ApiKey" "password"

dotnet add package Microsoft.Extensions.Configuration
dotnet add package Microsoft.Extensions.Configuration.UserSecrets

# windows : file location
# C:\Users\bm\AppData\Roaming\Microsoft\UserSecrets

```
