using BellySlide;

public class Program
{
    static void Main(string[] args)
    {
        var gameCaptureService = new GameCaptureService();
        var objectDetectionService = new ObjectDetectionService();
        var gameStateService = new GameStateService();
        var actionSelectionService = new ActionSelectionService();
        var gameInteractionService = new GameInteractionService();
        var trainingService = new TrainingService();

        while (true) // Main game loop
        {
            var gameScreen = gameCaptureService.CaptureScreen();
            var gameObjects = objectDetectionService.DetectObjects(gameScreen);
            var gameState = gameStateService.GetGameState(gameObjects);
            var gameAction = actionSelectionService.SelectAction(gameState);
            gameInteractionService.ExecuteAction(gameAction);

            // If using machine learning, you might also want to train your AI based on its performance
            // trainingService.TrainAI();
        }
    }
}
