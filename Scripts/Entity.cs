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

        public List<IComponent> Components { get { return this.components; } }

        int id;
        
        List<IComponent> components;
        
        public Entity () {
            this.id = new Random().Next();
            this.components = new List<IComponent>();
        }

        public int ID { get { return id; } }

        public void AddComponent(IComponent component) {
            this.components.Add(component);

            ValidateIfEntityHasRequiredComponents(component);
        }

        public void AddComponent<TComponent>() where TComponent: IComponent, new() {

            var component = new TComponent();
            this.components.Add(component);

            ValidateIfEntityHasRequiredComponents(component);
        }

        // Debugging // Move to unit test later
        void ValidateIfEntityHasRequiredComponents(IComponent component) {

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
         
        public void RemoveComponent(IComponent component) { 
            this.components.Remove(component);
        }

        public void RemoveComponent<TComponent>() where TComponent: IComponent {
            components.Remove(GetComponent<TComponent>());
        }

        public TComponent GetComponent<TComponent>() where TComponent : IComponent {
            foreach (var component in components) {
                if(component.GetType().Name == typeof(TComponent).Name) {
                    return (TComponent)component;
                }
            }
            throw (new Exception($"{typeof(TComponent).Name} not found! on Entity {this.GetType().Name},{this.id}"));
            return default(TComponent);
        }

        public bool HasComponent <TComponent>() where TComponent : IComponent {
            bool hasComponent = false;
            foreach (var component in components) {
                if (component.GetType().Name == typeof(TComponent).Name) {
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
