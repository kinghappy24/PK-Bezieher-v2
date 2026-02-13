#  Ticket System – Projekt Dokumentation



---

## Projektstruktur

Zu Beginn habe ich ein grobes Gerüst erstellt.

Für jede Logik habe ich eine eigene `.cs` Datei angelegt:

- Tickets
- Tariff
- PreisBerechner
- PH_Logik

Damit ich eine Bessere Übersicht habe

---

## Preisberechnung

Im `Tariff` wurde ein provisorischer Wert gesetzt:

```csharp
public double PreisProMinute { get; set; } = 0.015;
```

Ursprünglich gab es Probleme bei der Berechnung mit `TimeSpan`.  
Da man mit `TimeSpan` nicht direkt rechnen kann, wurde die Eigenschaft:

```
TotalMinutes
```

verwendet.

ich habe bewusst `PreisProMinute` statt `PreisProStunde` gewählt, um schneller sichtbare Resultate zu sehen.

---

## Zugriffmodifier (public / private / internal)

Anfangs wurden habe ich alle klassen praktisch Public gemacht.

Später habe ich gecheckt, dass `internal` Klassen nur innerhalb des Projekts sichtbar sind.  
Dadurch wurden folgende Objekte nicht erkannt:

```csharp
public PH_Logik Logik = new PH_Logik();
public Tickets GezogenerTicket;
```

Lösung:

```csharp
private PH_Logik Logik = new PH_Logik();
private Tickets GezogenerTicket;
```

---

## MAUI UI Probleme

### DisplayAlert Fehler

Es trat eine Überladungs-Fehlermeldung auf.  
Das Problem war, dass die Methode falsch aufgebaut war.

Dokumentation:
https://learn.microsoft.com/en-us/dotnet/maui/user-interface/pop-ups?view=net-maui-10.0

---

### OnAppearing()

Beim Öffnen einer Seite wird automatisch `OnAppearing()` ausgelöst.  
dass die daten beim neu Laden der Seute Aktualisieren.

Dokumentation:
https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.page.onappearing

---

## Bugs und Debugging

### Schreibfehler Bug

Problem:

```csharp
$"Bezahlt: {ticket.Bezahlt}";
```

In der Klasse `Tickets.cs` wurde  `Bezhalt` geschrieben.

Dieser kleine Tippfehler hat mir ein crash out gegeben.

---

### Kopier-Fehler

Beim Kopieren von `ticket-ansicht.xaml` nach `zahlung.xaml` wurden nicht alle Namen ersetzt.  
Dies führte zu weiteren Fehlern.

---

## Aktueller Stand

- Grundgerüst funktioniert
- Preisberechnung funktioniert
- UI ist noch nicht final
- Navigation (Shell Tabs) wurde manuell kopiert und angepasst
- Timer-Reset nach Zahlung funktioniert noch nicht korrekt

-edit - gelöst

---

## Offene Probleme

Nach Zahlung läuft der Timer weiter, obwohl er auf 0 zurückgesetzt werden sollte.
-edit - gelöst.

---

## Fazit

Das Projekt funktioniert grundsätzlich.  
Es gab viele kleinere Debugging-Probleme, besonders durch Schreibfehler oder Kopieren von Dateien.

