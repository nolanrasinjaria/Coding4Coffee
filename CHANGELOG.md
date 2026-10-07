# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added
- 21 command-enabled control types with intelligent parameter fallback
  - 3 standard desktop controls (DateTimePicker, NumericUpDown, TrackBar)
  - 12 localizable desktop controls
  - 3 specialized controls (DataGridView, TabControl, BindingNavigator)
  - 3 ToolStrip controls (ComboBox, TextBox, SplitButton)
- Fluent API with `Bind*Command()` methods for command chaining
- Debounce support for text input controls (300ms default)
- Intelligent command parameter fallback (SelectedItem, Text, SelectedTab.Name, etc.)
- Multiple event-specific commands for DataGridView and BindingNavigator
- ShowContextHelpCommand for control help management
- Community contribution guidelines (CONTRIBUTING.md)
- Code of Conduct (CODE_OF_CONDUCT.md)
- Issue and Pull Request templates
- CHANGELOG.md

### Changed
- Updated README.md with complete feature list and command control inventory
- Enhanced Coding4Coffee.WinForms README with specialized control behaviors
- Improved test coverage for command-support controls

### Fixed
- Removed stale test references to deleted redundant ToolStrip wrappers
- Cleaned up ToolStripCommandControlsTests.cs to test only existing controls

### Removed
- Redundant ToolStrip command-support wrappers (Button, DropDownButton, StatusLabel, Label)
- Non-localizable TabControlWithCommandSupport (replaced by LocalizableTabControlWithCommandSupport)

## [1.0.0] - 2026-10-07

### Added
- Initial release of Coding4Coffee libraries
- Coding4Coffee.Basics with configuration management, localization, and MVVM commands
- Coding4Coffee.WinForms with 45 localizable controls
- Form management commands (OpenFormCommand, CloseFormCommand)
- UI configuration serialization (Colors, Fonts, Icons, Images)
- Comprehensive XML documentation
- Unit tests for all major components
- MIT License
- SECURITY.md with security policy
- .gitignore with standard .NET patterns

### Security
- LibraryImport only policy for P/Invoke
- No custom unsafe blocks allowed
- Comprehensive code review checklist for security

[Unreleased]: https://github.com/nolanrasinjaria/Coding4Coffee/compare/v1.0.0...HEAD
[1.0.0]: https://github.com/nolanrasinjaria/Coding4Coffee/releases/tag/v1.0.0
