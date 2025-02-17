using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Dtos.IdValuePair;

namespace Soenneker.Zelos.Abstract;

/// <summary>
/// Defines the contract for a generic container storing documents in the Zelos database.
/// </summary>
public interface IZelosContainer : IDisposable
{
    IQueryable<T> BuildQueryable<T>();

    /// <summary>
    /// Adds a document to the container.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="document">The document to add.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The added document.</returns>
    ValueTask<string> AddItem(string id, string document, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a document by its ID.
    /// </summary>
    /// <param name="id">The ID of the document.</param>
    /// <returns>The document if found, otherwise null.</returns>
    string? GetItem(string id);

    /// <summary>
    /// Retrieves a document by its ID, throwing an exception if not found.
    /// </summary>
    /// <param name="id">The ID of the document.</param>
    /// <returns>The found document.</returns>
    string GetItemStrict(string id);

    /// <summary>
    /// Updates an existing document in the container.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="document">The updated document.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    ValueTask<string?> UpdateItem(string id, string document, CancellationToken cancellationToken = default);

    ValueTask<string> UpdateItemStrict(string id, string document, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a document from the container.
    /// </summary>
    /// <param name="id">The ID of the document.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    ValueTask DeleteItem(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all items in the container.
    /// </summary>
    /// <returns>A list of all stored documents.</returns>
    List<string> GetAllItems();

    List<string> GetAllIds();

    List<IdValuePair> GetZelosItems();

    ValueTask DeleteAllItems(CancellationToken cancellationToken = default);
}