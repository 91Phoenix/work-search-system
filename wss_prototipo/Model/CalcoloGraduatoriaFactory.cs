using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace WSS_Prototipo.Model
{
    static class CalcoloGraduatoriaFactory
    {
        private static readonly Dictionary<string, ICalcoloGraduatoria> _graduatorie = new Dictionary<string, ICalcoloGraduatoria>();
        private static readonly Dictionary<string, ICalcoloGraduatoriaFittizia> _graduatorieFittizie = new Dictionary<string, ICalcoloGraduatoriaFittizia>();

        static CalcoloGraduatoriaFactory()
        {
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type.GetInterface(typeof(ICalcoloGraduatoria).Name) != null && !type.IsAbstract)
                {
                    AddGraduatoria((ICalcoloGraduatoria)Activator.CreateInstance(type));
                }
                if (type.GetInterface(typeof(ICalcoloGraduatoriaFittizia).Name) != null && !type.IsAbstract)
                {
                    AddGraduatoriaFittizia((ICalcoloGraduatoriaFittizia)Activator.CreateInstance(type));
                }
            }
        }

        public static ICalcoloGraduatoria GetCalcoloGraduatoria(string name)
        {
            if (!_graduatorie.ContainsKey(name))
                throw new ArgumentException("!_graduatorie.ContainsKey(nome)");
            return _graduatorie[name];
        }
        public static ICalcoloGraduatoriaFittizia GetCalcoloGraduatoriaFittizia(string name)
        {
            if (!_graduatorieFittizie.ContainsKey(name))
                throw new ArgumentException("!_graduatorieFittiriza.ContainsKey(nome)");
            return _graduatorieFittizie[name];
        }
        public static IEnumerable<ICalcoloGraduatoria> GetCalcoliGraduatoria()
        {
            return _graduatorie.Values;
        }
        public static IEnumerable<ICalcoloGraduatoriaFittizia> GetCalcoliGraduatoriaFittizia()
        {
            return _graduatorieFittizie.Values;
        }
        private static void AddGraduatoria(ICalcoloGraduatoria calcolo)
        {
            if (calcolo == null)
                throw new ArgumentNullException("calcolo");
            if (_graduatorie.ContainsKey(calcolo.GetType().Name))
                throw new ArgumentException("calcolo already exist");
            _graduatorie.Add(calcolo.GetType().Name, calcolo);
        }
        private static void AddGraduatoriaFittizia(ICalcoloGraduatoriaFittizia calcolo)
        {
            if (calcolo == null)
                throw new ArgumentNullException("calcolo");
            if (_graduatorieFittizie.ContainsKey(calcolo.GetType().Name))
                throw new ArgumentException("calcolo already exist");
            _graduatorieFittizie.Add(calcolo.GetType().Name, calcolo);
        }
    }
}
