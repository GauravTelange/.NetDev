# Apache httpd + Kestrel lab (same idea as your sir's video)

Your MVC app runs on **Kestrel** (.NET). **Apache** only forwards browser traffic (reverse proxy). This is **not** Tomcat.

## Architecture

```
Browser  -->  Apache (port 80)  -->  Kestrel/dotnet (port 5005)  -->  CustomerApplication.dll
```

IIS on port 76 is separate; stop it or use another Apache port if both conflict.

---

## Step 1 — Install Apache to `C:\Apache24` (like the video)

1. Install [VC++ Redistributable x64](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist).
2. Download **httpd-2.4.67 Win64 VS18** zip from [Apache Lounge](https://www.apachelounge.com/download/).
3. Extract so you have `C:\Apache24\bin\httpd.exe` and `C:\Apache24\conf\httpd.conf`.

**Admin CMD:**

```cmd
cd C:\Apache24\bin
httpd.exe -k install
```

---

## Step 2 — Publish MVC app to `C:\Website123`

```cmd
dotnet publish C:\Users\Admin\source\repos\CustomerApplication\CustomerApplication\CustomerApplication.csproj -c Release -o C:\Website123
```

(Your sir may use `C:\MyWeb123` — same idea; change the path in `start-kestrel.bat` if needed.)

---

## Step 3 — Edit `C:\Apache24\conf\httpd.conf` (EditPlus in the video)

### A. ServerRoot (usually already set)

```apache
ServerRoot "c:/Apache24"
```

### B. Listen on port 80

Find `#Listen 12.34.56.78:80` and ensure you have:

```apache
Listen 80
```

If IIS uses port 80, use `Listen 8080` and open `http://localhost:8080/`.

### C. Enable proxy modules

Uncomment (remove `#` from) these lines:

```apache
LoadModule proxy_module modules/mod_proxy.so
LoadModule proxy_http_module modules/mod_proxy_http.so
```

### D. Include this lab config (bottom of httpd.conf)

```apache
Include conf/extra/customerapp-proxy.conf
```

Copy `apache-lab\extra\customerapp-proxy.conf` from this repo to:

`C:\Apache24\conf\extra\customerapp-proxy.conf`

---

## Step 4 — Test Apache config

**Admin CMD:**

```cmd
cd C:\Apache24\bin
httpd.exe -t
```

Must say `Syntax OK`.

---

## Step 5 — Run the lab (two windows)

**Window 1 — Kestrel (keep open):**

```cmd
C:\Users\Admin\source\repos\CustomerApplication\apache-lab\start-kestrel.bat
```

Test: http://127.0.0.1:5005/ should show Customer screen.

**Window 2 — Apache (Admin):**

```cmd
cd C:\Apache24\bin
httpd.exe -k start
```

**Browser:** http://localhost/

You should see the same MVC app through Apache.

---

## Step 6 — Stop services

```cmd
cd C:\Apache24\bin
httpd.exe -k stop
```

Close the Kestrel window (Ctrl+C).

---

## Troubleshooting

| Problem | Fix |
|--------|-----|
| Apache won't start | Port 80 in use (IIS/W3SVC). Stop IIS site or use `Listen 8080`. |
| 502 Bad Gateway | Start `start-kestrel.bat` first. |
| 404 on localhost | Fix `Program.cs` routes; republish to `C:\Website123`. |
| `httpd.exe -t` fails | Check `Include` path and proxy modules enabled. |

---

## Optional: still use IIS (port 76)

You can keep IIS for class demos and use Apache only for this lab on port **80** or **8080**.
