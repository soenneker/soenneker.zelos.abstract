[![](https://img.shields.io/nuget/v/soenneker.zelos.abstract.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.zelos.abstract/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.zelos.abstract/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.zelos.abstract/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.zelos.abstract.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.zelos.abstract/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.zelos.abstract/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.zelos.abstract/actions/workflows/codeql.yml)

# Soenneker.Zelos.Abstract

Defines the contract for a generic container storing documents in the Zelos database.

## Install

```bash
dotnet add package Soenneker.Zelos.Abstract
```

## Quick start

```csharp
using Soenneker.Zelos.Abstract;

IZelosContainer zelosContainer = /* resolve from DI */;
var result = zelosContainer.BuildQueryable();
```

Builds queryable.

## What you get

- `IZelosContainer` — Defines the contract for a generic container storing documents in the Zelos database.
- `IZelosDatabase` — A lightweight, thread-safe asynchronous JSON-based document database.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `IZelosContainer.AddItem(id, document, cancellationToken)` | Adds a document to the container. | The added document. |
| `IZelosContainer.GetItem(id)` | Retrieves a document by its ID. | The document if found, otherwise null. |
| `IZelosContainer.GetItemStrict(id)` | Retrieves a document by its ID, throwing an exception if not found. | The found document. |
| `IZelosContainer.UpdateItem(id, document, cancellationToken)` | Updates an existing document in the container. | A task whose result is the text returned by update Item. |
| `IZelosContainer.DeleteItem(id, cancellationToken)` | Deletes a document from the container. | Completes when the requested deletion has finished. |
| `IZelosContainer.GetAllItems()` | Retrieves all items in the container. | A list of all stored documents. |
| `IZelosDatabase.MarkDirty(containerName, cancellationToken)` | Marks a container as dirty, indicating it needs to be saved. Typically, is not needed to be called manually, but available. | A ValueTask representing the asynchronous operation. |
| `IZelosDatabase.GetContainer(containerName, cancellationToken)` | Retrieves container. | A ValueTask containing the requested ZelosContainer. |
| `IZelosDatabase.Save(cancellationToken)` | Saves any dirty containers to persistent storage if needed. Typically, is not needed to be called manually, but available. | A Task representing the asynchronous operation. |
| `IZelosDatabase.UnloadContainer(containerName, cancellationToken)` | Unloads the named container from the database. | true if the container was unloaded; otherwise, false. |

## Practical notes

- Cancellation stops pending work; it does not undo work that has already completed.
- Dispose instances you own when their scope ends so held resources can be released.
