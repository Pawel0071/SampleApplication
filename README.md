# SampleApplication

A simple WPF (.NET 8) application demonstrating a clean MVVM architecture with SOLID principles, Prism for DI, modularity, and region-based navigation.

## Features
- MVVM with `ViewModelBase` and property change notifications
- Strategy pattern for text checking (`ICheckStrategy` and resolver)
- Prism DI (`PrismApplication`), module (`TextModule`), and region navigation (`MainRegion`)
- Validation using `INotifyDataErrorInfo` with localized messages
- Unit tests (xUnit, Moq) for strategies and view models

## Getting Started
- Prerequisites: .NET 8 SDK, Visual Studio 2022 (or newer)
- Build: open the solution and build, or run `dotnet build` in the solution directory
- Run: start `SampleApplication` project; the main window hosts a region that navigates to `TextView`

## Structure
- `Model`: domain models and check strategies
- `ViewModel`: `TextViewModel`, `MainWindowViewModel` (interfaces for DI)
- `View`: WPF views (`MainWindow`, `TextView`) with bindings
- `Modules`: Prism module registration (`TextModule`)
- `Services`: app-level abstractions (e.g., `IApplicationService`)
- `Resources`: localized UI strings
- `SampleApplication.Tests`: unit tests targeting net8.0-windows

## Usage
Enter text, select a condition and value, and click "SprawdŸ" (Check). Results and validation messages are shown. Close the app with the "Zakoñcz" (Close) button.

## Notes
- Regions require supported hosts (e.g., `ContentControl`).
- Validation messages appear after submission and are localized via `Resources/Strings.cs`.
