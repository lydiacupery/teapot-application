using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive;
using static TeapotApplication.State;

namespace TeapotApplication
{
    public class MainWindowViewModel : ReactiveObject
    {
        TeapotState _teapotState;
        public TeapotState TeapotCurrentState
        {
            get { return _teapotState; }
            set { this.RaiseAndSetIfChanged(ref _teapotState, value); }
        }
        TeapotState _teapotState2;
        public TeapotState TeapotCurrentState2
        {
            get { return _teapotState2; }
            set { this.RaiseAndSetIfChanged(ref _teapotState2, value); }
        }

        string _teapotMessage;
        public string TeapotMessage
        {
            get { return _teapotMessage; }
            set { this.RaiseAndSetIfChanged(ref _teapotMessage, value); }
        }

        public bool TupleContainsAtleastOne(TeapotState state, Tuple<TeapotState, TeapotState> teapotState)
        {
            return (teapotState.Item1 == state || teapotState.Item2 == state);
        }

        public bool TupleContainsTwo(TeapotState state, Tuple<TeapotState, TeapotState> teapotState)
        {
            return (teapotState.Item1 == state && teapotState.Item2 == state);
        }



        public MainWindowViewModel() {
            TeapotCurrentState = TeapotState.Whistling;
            CheckWhistlingCommand = ReactiveCommand.Create(() => TeapotCurrentState = TeapotState.Whistling);
            CheckNotWhistlingCommand = ReactiveCommand.Create(() => TeapotCurrentState = TeapotState.NotWhistling);
            CheckBoilingOverCommand = ReactiveCommand.Create(() => TeapotCurrentState = TeapotState.BoilingOver);
            CheckWhistlingCommand2 = ReactiveCommand.Create(() => TeapotCurrentState2 = TeapotState.Whistling);
            CheckNotWhistlingCommand2 = ReactiveCommand.Create(() => TeapotCurrentState2 = TeapotState.NotWhistling);
            CheckBoilingOverCommand2 = ReactiveCommand.Create(() => TeapotCurrentState2 = TeapotState.BoilingOver);

            var teapotOneObservable = this.WhenAnyValue(x => x.TeapotCurrentState);
            var teapotTwoObservable = this.WhenAnyValue(x => x.TeapotCurrentState2);

            Observable.CombineLatest(teapotOneObservable, teapotTwoObservable, (teapot1, teapot2) => Tuple.Create(teapot1, teapot2)).Subscribe(tuple =>
            {
                TeapotMessage = State.EnumToStringDictionary[tuple];
            });

        }

        public ReactiveCommand<Unit, TeapotState> CheckWhistlingCommand { get; private set; }
        public ReactiveCommand<Unit, TeapotState> CheckNotWhistlingCommand { get; private set; }
        public ReactiveCommand<Unit, TeapotState> CheckBoilingOverCommand { get; private set; }
        public ReactiveCommand<Unit, TeapotState> CheckWhistlingCommand2 { get; private set; }
        public ReactiveCommand<Unit, TeapotState> CheckNotWhistlingCommand2 { get; private set; }
        public ReactiveCommand<Unit, TeapotState> CheckBoilingOverCommand2 { get; private set; }

    }
}
