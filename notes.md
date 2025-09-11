# Notes



## Threads

Een thread? Een proces?
Een Task?

Thread? De CPU? Logische threads.

### Waarom is dit alles belangrijk?

- high performance
- UI responsive houden. Zeker bij:
  - apps op smartphones
  - desktopapps
- vele concurrent requests kunnen afhandelen bij een webserver

UIs in .NET
- Windows Forms (drag en drop van componenten op een schermpje)
- WPF (XAML)
- MAUI (ook XAML, ik hoor zelden goeie ervaringen)
- Blazor voor desktopapp

### Synchronization primitives

Bedoeld om threads samen laten werken

- Semaphore - uitsmijter bij een club. Er mogen 200 mensen in de club, de rest moet wachten.
- Mutex - "mutually exclusive". WC-sleutel, 1 persoon mag van de wc gebruik maken.
- Barrier - wacht tot iedereen er is, dan pas verder
- ReaderWriterLock - meerdere lezers, 1 schrijver

Deadlock? Threads die meerdere resources willen gebruiken, maar eeuwig wachten op een andere thread om de lock vrij te geven.

## Tasks

`Task`
- abstractie over `Thread`
- Thread of niet wordt gemanaged door runtime
- is een stukje werk
  - KAN op een aparte thread worden uitgevoerd - runtime bepaalt!
- gaat gepaard met `async`/`await`
- hier zul je WEL veel mee werken

`Task` aanmaken:
- `new Task().Start()`
- `Task.Run()`
- `TaskFactory.StartNew()`
- `Parallel LINQ`
- `Parallel.For()` en `Parallel.Invoke()`

```cs
lijstje.AsParallel().Where(x => true);
```

## `async`/`await`

Is allemaal bedacht om de ![cost of I/O](https://blog.mixu.net/files/2011/01/io-cost.png) te verminderen: threads niet laten wachten op I/O-operaties, maar ze laten terugkeren naar de threadpool om andere dingen te doen.

Het is gewoon gek dat deze synchrone geheugenallocatie:

```cs
int getal = 14;
```

Op hetzelfde niveau wordt geplaatst met dit soort I/O-operaties qua hoeveel moeite de CPU ervoor moet doen:

```cs
// PHP
mysql_query($query);

// Java
em.persist(obj);

// .NET
context.SaveChanges();
reader.ExecuteReader();
```

- `async` is een signaal voor de compiler dat er asynchrone operaties in zitten (`await` mogen gebruiken)
- `await` is waar de compiler je methode in stukjes knipt

Vele webframeworks in .NET/Java/PHP/... werkten volgens "elke request = nieuwe thread".

10.000.000 requests/seconde = 10.000.000 nieuwe threads = 1MB stack in het geheugen reserveren per threads = 10.000GB RAM benodigd.
