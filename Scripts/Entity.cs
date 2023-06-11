using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
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
        
        List<Component> components;
        
        public Entity () {
            this.id = new Random().Next();
            this.components = new List<Component>();
        }

        public int ID { get { return id; } }

        public void AddComponent(Component component) {
            this.components.Add(component);

            ValidateIfEntityHasRequiredComponents(component);
        }

        public void AddComponent<T>() where T: Component, new() {

            var component = new T();
            this.components.Add(component);

            ValidateIfEntityHasRequiredComponents(component);
        }

        // Debugging // Move to unit test later
        void ValidateIfEntityHasRequiredComponents(Component component) {

            List<string> missingComponents = new List<string>();

            for (var x = 0; x < component.REQUIRED_COMPONENTS.Length; ++x) {
                var hasMatch = false;

                foreach (var equippedComponent in components) {
                    var capitalizedRequiredComponent = component.REQUIRED_COMPONENTS[x].ToUpper();
                    var capitalizedEquippedComponent = equippedComponent.GetType().Name.ToUpper();
                    
                    if(capitalizedRequiredComponent == capitalizedEquippedComponent) {
                        hasMatch = true;
                    }
                }
                if (!hasMatch) {
                    missingComponents.Add(component.REQUIRED_COMPONENTS[x]);
                }
            }

            foreach(var missingComponent in missingComponents) {
                throw (new Exception($"Entity ({this.GetType().Name},id:{this.id}), Component: {component.GetType().Name} is missing the required Component: {missingComponent}"));
            }
        }
         
        public void RemoveComponent(Component component) { 
            this.components.Remove(component);
        }

        public void RemoveComponent<T>() where T: Component {
            components.Remove(GetComponent<T>());
        }

        public T GetComponent<T> () where T : Component {
            foreach (var component in components) {
                if(component.GetType().Name == typeof(T).Name) {
                    return (T)component;
                }
            }
            return default(T);
        }

        public bool HasComponent <T>() where T : Component {
            bool hasComponent = false;
            foreach (var component in components) {
                if (component.GetType().Name == typeof(T).Name) {
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
