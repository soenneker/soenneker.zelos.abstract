using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Zelos.Abstract;

/// <summary>
/// A lightweight, thread-safe asynchronous JSON-based document database
/// </summary>
public interface IZelosDatabase : IAsyncDisposable
{
    /// <summary>
    /// Marks a container as dirty, indicating it needs to be saved. Typically, is not needed to be called manually, but available.
    /// </summary>
    /// <param name="containerName">The name of the container.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A ValueTask representing the asynchronous operation.</returns>
    ValueTask MarkDirty(string containerName, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves container.
    /// </summary>
    /// <param name="containerName">Name of the container to target.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A ValueTask containing the requested ZelosContainer.</returns>
    ValueTask<IZelosContainer> GetContainer(string containerName, CancellationToken cancellationToken = default);

    /// <summary>
    /// Saves any dirty containers to persistent storage if needed. Typically, is not needed to be called manually, but available.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A Task representing the asynchronous operation.</returns>
    ValueTask Save(CancellationToken cancellationToken = default);

    /// <summary>
    /// Unloads the named container from the database.
    /// </summary>
    /// <param name="containerName">Name of the container to target.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>true if the container was unloaded; otherwise, false.</returns>
    ValueTask<bool> UnloadContainer(string containerName, CancellationToken cancellationToken = default);
}
