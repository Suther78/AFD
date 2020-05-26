using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSM_Simple{
   public class AFD{
      private readonly List<string> Q = new List<string>();
      private readonly List<char> Sigma = new List<char>();
      private readonly List<Transition> Delta = new List<Transition>();
      private string Q0;
      private readonly List<string> F = new List<string>();

      public AFD(IEnumerable<string> q, IEnumerable<char> sigma, IEnumerable<Transition> delta, string q0, IEnumerable<string> f){
         Q = q.ToList();
         Sigma = sigma.ToList();
         AgregarTransi(delta);
         AgregarInicio(q0);
         AgregarEstadosfinales(f);
      }

      private void AgregarTransi(IEnumerable<Transition> transitions){
         foreach (var transition in transitions.Where(ValidarTransicion)){
            Delta.Add(transition);
         }
      }

      private bool ValidarTransicion(Transition transition){
         return Q.Contains(transition.StartState) &&
                Q.Contains(transition.EndState) &&
                Sigma.Contains(transition.Symbol) &&
                !TransicionDefinida(transition);
      }

      private bool TransicionDefinida(Transition transition){
         return Delta.Any(t => t.StartState == transition.StartState &&
                               t.Symbol == transition.Symbol);
      }

      private void AgregarInicio(string q0){
         if (q0 != null && Q.Contains(q0)){
            Q0 = q0;
         }
      }

      private void AgregarEstadosfinales(IEnumerable<string> finalStates){
         foreach (var finalState in finalStates.Where(finalState => Q.Contains(finalState))){
            F.Add(finalState);
         }
      }

      public void Acepta(string input){
         ConsoleWriter.Success("Leyendo: " + input);
         if (InputInvalido(input)){
            return;
         }
         var currentState = Q0;
         var steps = new StringBuilder();
         foreach (var symbol in input.ToCharArray()){
            var transition = Delta.Find(t => t.StartState == currentState &&
                                             t.Symbol == symbol);
            if (transition == null){
               ConsoleWriter.Failure("No existe tal transicion para ese simbolo");
               ConsoleWriter.Failure(steps.ToString());
               return;
            }
            currentState = transition.EndState;
            steps.Append(transition + "\n");
         }
         if (F.Contains(currentState)){
            ConsoleWriter.Success("Aceptada:\n" + steps);
            return;
         }
         ConsoleWriter.Failure("Se detuvo en el estado " + currentState +
                               " El cual no es el estado final.");
         ConsoleWriter.Failure(steps.ToString());
      }

      private bool InputInvalido(string input){
         if (NoSym(input)){
            return true;
         }
         if (EstadoIninotset()){
            ConsoleWriter.Failure("No se agrego ningun estado inicial");
            return true;
         }
         if (NoEstadosFin()){
            ConsoleWriter.Failure("No se agrego ningun estadofinal");
            return true;
         }
         return false;
      }

      private bool NoSym(string input){
         foreach (var symbol in input.ToCharArray().Where(symbol => !Sigma.Contains(symbol))){
            ConsoleWriter.Failure("No se acepto la cadena por que este simbolo " + symbol + " no es parte del alfabeto");
            return true;
         }
         return false;
      }

      private bool EstadoIninotset(){
         return string.IsNullOrEmpty(Q0);
      }

      private bool NoEstadosFin(){
         return F.Count == 0;
      }
   }
}
