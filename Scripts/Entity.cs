using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Terrain_Maker.Scripts.Components;

namespace Terrain_Maker.Scripts
{
    public abstract class Entity {

        public List<Component> Components { get { return this.components; } }

        int id;
        IntVector2 position, size;
        List<Component> components;
        
        public Entity () {
            this.position = IntVector2.Zero;
            this.size = IntVector2.Zero;
            this.id = new Random().Next();
            this.components = new List<Component>();
        }

        public int ID { get { return id; } }
        public IntVector2 Position { get { return position; } }
        public IntVector2 Size { get {  return size; } }

        public void Move(int x, int y) {
            this.position = new IntVector2(x, y);
        }

        public void Resize(int width, int height) {
            this.size = new IntVector2(width, height);
        }

        public void AddComponent(Component component) {
            this.components.Add(component);
        }

        public void AddComponent<T>() where T: Component, new() {
            this.components.Add(new T());
        }
         
        public void RemoveComponent(Component component) { 
            this.components.Remove(component);
        }

        public void RemoveComponent<T>() where T: Component {
            components.Remove(GetComponent<T>());
        }

        // not sure if it works since it is returning another value made inside of the function
        public T GetComponent<T> () where T : Component {
            Component foundComponent = new EmptyComponent();
            
            foreach (var component in components) {
                if(component.GetType().ToString() == typeof(T).Name) {
                    foundComponent = component;
                }
            }
            return (T)foundComponent;
        }

        public bool HasComponent <T>() where T : Component {
            bool hasComponent = false;
            foreach (var component in components) {
                if (component.GetType().ToString() == typeof(T).Name) {
                    hasComponent = true;
                }
            }
            return hasComponent;
        }
    }

    public class EmptyEntity : Entity {
        public EmptyEntity() {
        }
    }
}
