namespace UnityGOAP {
    public interface IGOAPUpdateListener {
        void OnUpdate(GOAPAgent agent);
    }

    public interface IGOAPInitListener {
        void OnInit(GOAPAgent agent);
    }

    public interface IGOAPTerminateListener {
        void OnTerminate(GOAPAgent agent);
    }
}