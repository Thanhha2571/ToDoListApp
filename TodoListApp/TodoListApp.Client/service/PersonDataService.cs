using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoListApp.Client.Models;

namespace TodoListApp.Client.service;

public class PersonDataService
{
    private readonly ILocalStorageService _localStorage;
    private const string StorageKey = "people";

    public PersonDataService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task<List<Person>> GetPeopleAsync()
    {
        return await _localStorage.GetItemAsync<List<Person>>(StorageKey) ?? [];
    }

    public async Task AddPersonAsync(Person newPerson)
    {
        var people = await GetPeopleAsync();
        newPerson.Id = people.Any() ? people.Max(p => p.Id) + 1 : 1;
        people.Add(newPerson);
        await _localStorage.SetItemAsync(StorageKey, people);
    }
}
