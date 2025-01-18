# GmailDeleteUI

GmailDeleteUI is a simple Windows Forms application that helps you delete emails from a specific sender in your Gmail account using the Gmail API. With an easy-to-use graphical interface, it makes email cleanup fast and efficient.

---

## Features

- Delete all emails from a specified sender.
- Intuitive, easy-to-use graphical interface (no command-line required).
- Logs the deletion progress in real-time.
- Uses Google's Gmail API for secure email management.

---

## Requirements

- A Google account with access to Gmail.
- A **`credentials.json`** file generated from the Google Cloud Console for Gmail API access (see below for instructions).

---

## Setup Instructions

### Step 1: Download the Application
1. Go to the [Releases](https://github.com/th3j35ter/GmailDeleteUI/releases) page.
2. Download the latest version of the application (e.g., `GmailDeleteUI.exe`).

### Step 2: Set Up the `credentials.json` File
1. Go to the [Google Cloud Console](https://console.cloud.google.com/).
2. Create a new project or use an existing one.
3. Enable the **Gmail API** for your project:
   - Navigate to **APIs & Services** > **Library**.
   - Search for "Gmail API" and click **Enable**.
4. Configure OAuth consent:
   - Navigate to **APIs & Services** > **OAuth consent screen**.
   - Fill out the required details and publish the consent screen.
5. Create OAuth 2.0 credentials:
   - Go to **APIs & Services** > **Credentials** > **Create Credentials** > **OAuth Client ID**.
   - Select "Desktop App" as the application type.
   - Download the generated `credentials.json` file.
6. Place the `credentials.json` file in the same directory as `GmailDeleteUI.exe`.

---

## How to Use

1. **Run the Application**:
   - Double-click `GmailDeleteUI.exe` to launch it.

2. **Authenticate with Gmail**:
   - On the first run, a browser window will open, prompting you to log in to your Google account.
   - Grant the necessary permissions to allow the app to access your Gmail.

3. **Enter the Sender's Email Address**:
   - In the application, enter the email address of the sender whose emails you want to delete.

4. **Start the Cleanup**:
   - Click **Trash Emails**.
   - The app will move all emails from the specified sender to the Trash.
   - Check the logs for progress and completion messages.

---

## Troubleshooting

1. **Missing `credentials.json`**:
   - Ensure the `credentials.json` file is in the same folder as `GmailDeleteUI.exe`.
   - If the file is missing or invalid, follow the setup instructions to generate a new one.

2. **Authentication Issues**:
   - If you're unable to authenticate, ensure you have enabled the Gmail API for your project and have an active internet connection.

3. **No Emails Found**:
   - Ensure the sender's email address is entered correctly.
   - Verify that emails from the specified sender exist in your Gmail account.

---

## Disclaimer

This application uses the Gmail API and requires authentication through OAuth 2.0. It complies with Google's [API Terms of Service](https://developers.google.com/terms). Use this tool responsibly and ensure you have appropriate permissions to delete emails.

---

## License

This project is licensed under the [MIT License](LICENSE).
