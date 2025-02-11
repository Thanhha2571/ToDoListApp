using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoListApp.Client.Models;

namespace TodoListApp.Client.service;
 
public class ToDoItemDataService
{
    private readonly ILocalStorageService _localStorage;
    private const string StorageKey = "tasks";

    public ToDoItemDataService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task<List<ToDoItem>> GetTasksAsync()
    {
        return await _localStorage.GetItemAsync<List<ToDoItem>>(StorageKey) ?? [];
    }

    public async Task AddTaskAsync(ToDoItem newTask)
    {
        var tasks = await GetTasksAsync();
        newTask.Id = tasks.Any() ? tasks.Max(t => t.Id) + 1 : 1;
        tasks.Add(newTask);
        await SaveTasksAsync(tasks);
    }

    public async Task UpdateTaskAsync(ToDoItem updatedTask)
    {
        var tasks = await GetTasksAsync();
        var existingTask = tasks.FirstOrDefault(t => t.Id == updatedTask.Id);
        if (existingTask != null)
        {
            existingTask.Name = updatedTask.Name;
            existingTask.Status = updatedTask.Status;
            existingTask.Category = updatedTask.Category;
            existingTask.Deadline = updatedTask.Deadline;
            await SaveTasksAsync(tasks);
        }
    }

    public async Task DeleteTaskAsync(int taskId)
    {
        var tasks = await GetTasksAsync();
        tasks.RemoveAll(t => t.Id == taskId);
        await SaveTasksAsync(tasks);
    }

    private async Task SaveTasksAsync(List<ToDoItem> tasks)
    {
        await _localStorage.SetItemAsync(StorageKey, tasks);
    }
}
