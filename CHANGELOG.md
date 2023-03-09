# Version 1.6
- Improved Refresh responsiveness by using BackgroundWorker.
- Improved Refresh speed by utilising an internal cache.
- Added ability to sort columns in ascending or descending order.
- Changed toolbar icons.

# Version 1.5
- Improved Refresh speed by using TPL (.NET 4 Task Parallel Library)
- New option on Settings page to flag if assemblies backup should 
  occur during Install and Uninstall operations.
- Install Assembly and Unistall Assembly processes updated to backup 
  assemblies to Backup sub-folder if backup flag is set.
- New toolstrip button to show backup folder.

# Version 1.4
- Correctly handles the cancellation of Install Assembly dialog.
- Changed toolbar icons.

# Version 1.3
- Displays the assembly image runtime version on Properties page.
- Handles spaces contained in the assembly path.
- Improved application startup speed.
- Progress bar displays in status bar during refresh.
- Various minor tweaks.

# Version 1.2
- Additional feature added to allow assemblies to be exported.
- Validation added to prevent multiple copies of application running.
- Added this About page and a new Settings page.
- Various minor tweaks.

# Version 1.1
- Support for managing CLR 2.0 assemblies (.NET 2.x and .NET 3.x).
- Ability to filter on CLR 2.0 and CLR 4.0 assemblies.
- Various minor tweaks.

# Version 1.0
- Initial version to address .NET 4.0 not having a graphical interface for 
  managing the CLR 4.0 global assembly cache.
- Ability to view, filter, install and uninstall CLR 4.0 assemblies.
- Ability to view assembly properties.
- Drag and drop assembly install support.
- Keyboard shortcuts added for refresh (F5) and uninstall assembly (Delete).