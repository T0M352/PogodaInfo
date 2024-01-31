Aplikacja Pogodowa z wykorzystaniem ASP.NET Core i Windows Forms

Zestaw aplikacji składający się z serwisu ASP.NET Core oraz aplikacji desktopowej stworzonej w frameworku Windows Forms, 
zaprojektowany do monitorowania aktualnych danych pogodowych w Polsce. Serwis łączy się z publicznym API strony imgw.danepubliczne.pl, 
pobierając informacje o aktualnej pogodzie w formacie JSON.


Serwis ASP.NET Core działa jako warstwa pośrednicząca pomiędzy API imgw.danepubliczne.pl a aplikacją desktopową. 
Współpracuje z API, pobierając aktualne dane pogodowe w formie JSON. Serwis oferuje jednolite API, 
które umożliwia łatwe pobieranie danych pogodowych dla konkretnych lokalizacji.


Aplikacja desktopowa, oparta na frameworku Windows Forms w technologii .NET, stanowi interfejs użytkownika do monitorowania pogody. 
Pozwala użytkownikowi na wybór konkretnej lokalizacji na mapie Polski i wyświetlenie aktualnych danych pogodowych, 
takich jak temperatura i ciśnienie atmosferyczne. Aplikacja komunikuje się z serwisem ASP.NET Core, zapewniając szybki dostęp do aktualnych informacji pogodowych.
