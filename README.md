# Alfie
Alfie is a Blazor app that allows users to communicate with Chat GPT model using both text and voice input. The app utilizes Azure Cognitive Services for the model and text-to-speech functionality and vice versa.

![image](https://user-images.githubusercontent.com/22825924/228656773-9f889013-956e-42b1-8cfb-8c1fa576c8f4.png)

# Features
- Text-based chat interface for users to interact with Chat GPT
- Voice-based chat interface for users to interact with Chat GPT
- Azure Cognitive Services integration for natural language processing and text-to-speech
- Responsive UI design for optimal user experience across different devices

# Technologies
- Blazor
- C#
- Azure Cognitive Services
- Open Ai
- Bootstrap

# Getting Started
Prerequisites:
- .NET 6 SDK
- Azure Cognitive Services API key and region
- Open Ai API key

# Installation
1. Clone the repository: git clone https://github.com/Nemadjo94/Alfie.git
2. Navigate to the project directory: cd your-repo
3. Set the OpenAiApi key value in the appsettings.json file to your Open Ai API key.
4. Set the AzureCognitiveServices Key and Region values in the appsettings.json file to your Azure Cognitive Services API key and region, respectively.
5. Run the app: dotnet run

# Usage
- Open the app in a web browser
- Enter your message in the text input field and click the "Send" button to send a text message to the chatbot
- Click the microphone button to enable voice input and speak your message. The app will transcribe your message and send it to the chatbot.
- The chatbot will respond to your messages in both text and voice format

# Credits
This app was created by Nemanja Djordjevic.

# License
This project is licensed under the MIT License.
