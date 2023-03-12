namespace UI
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using Object = UnityEngine.Object;

    public class UIBuilder : IUIBuilder
    {
        private readonly UIRoot uiRoot;
        
        private readonly IDictionary<string, Window> cache = new Dictionary<string, Window>();
        
        private const string UIPath = "UI";
        
        public UIBuilder()
        {
            uiRoot = Object.FindObjectOfType<UIRoot>();
        }
        
        public T CreateWindow<T>() where T : Window
        {
            var name = typeof(T).Name;
            Window prefab = LoadPrefab(name);
            
            if (prefab == null)
                throw new Exception($"There`s no prefab for {name}");

            var window = Object.Instantiate(prefab, uiRoot.transform);

            return window as T;
        }

        private Window LoadPrefab(string name)
        {
            var prefab = FindInCache(name);

            if (prefab == null)
            {
                prefab = LoadFromResources(name);
                AddToCache(name, prefab);
            }

            return prefab;
        }

        private Window LoadFromResources(string name)
        {
            return Resources.Load<Window>($"{UIPath}/{name}");
        }

        private Window FindInCache(string name)
        {
            cache.TryGetValue(name, out var prefab);
            return prefab;
        }
        
        private void AddToCache(string name, Window prefab)
        {
            cache[name] = prefab;
        }
    }
}