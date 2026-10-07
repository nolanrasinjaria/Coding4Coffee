# Copilot Instructions

## Project Guidelines
- Coding4Coffee.WinForms Stil-Richtlinien für Command Support Controls:

1. NAMENSKONVENTIONEN:
   - Lokalizable Base: LocalizableXxxControl (erbt von WinForms Control)
   - Mit CommandSupport: LocalizableXxxControlWithCommandSupport (erbt von Localizable-Variante)
   - Commands: XxxCommand (z.B. ShowContextHelpCommand)
   - ToolStrip-Varianten: LocalizableToolStripXxxWithCommandSupport

2. PROPERTY PATTERNS:
   - Explizites 'new' Keyword für Properties, die von ToolStripItem geerbt werden
   - Grund: Vermeidung von CS0108 Warnings, da .NET 10 ToolStripItem.Command/CommandParameter hat
   - XML-Remarks dokumentieren das Shadowing intentional
   - DesignerSerializationVisibility(Hidden) für Command-Properties

3. COMMAND-SUPPORT STRUKTUR:
   - Separate ICommand? und object? Felder für jedes Command
   - Public Property mit Getter/Setter für Command und CommandParameter
   - Private Event-Handler Methoden (z.B. Command_CanExecuteChanged)
   - Fluent BindXxxCommand(ICommand, object?) Methode für Kettenaufrufe
   - #region für Organization bei mehreren Commands (wie DataGridView)

4. DEFAULT-PARAMETER:
   - Intelligent fallback: CommandParameter ?? DefaultValue
   - Beispiele: SelectedItem (ComboBox), Text (TextBox), SelectedTab.Name (TabControl)
   - XML-Remarks erklären den Default-Fallback-Mechanismus

5. EVENT-HANDLING:
   - Debounce-Timer für kontinuierliche Input (TextBox 300ms, DataGridView konfigurierbar)
   - SelectionChangeCommitted statt SelectedIndexChanged (nur User-Aktionen)
   - Event-Routen durch Private Handler-Methoden
   - Proper Subscribe/Unsubscribe in Command Setter und Dispose

6. XML-DOKUMENTATION:
   - Extensive <summary>, <remarks>, <param>, <returns> Tags
   - API-Links via <see cref="..."/> 
   - Erklärung des Behaviors in Remarks
   - Darstellung von Intelligenz bei Default-Parametern

7. DISPOSE-PATTERN:
   - Override Dispose(bool) für Timer und BindingSource Cleanup
   - Unsubscribe von Events vor dem base.Dispose()

8. CONSTRUCTOR:
   - Event-Subscriptions im Constructor (z.B. für Timer Tick)
   - Nicht lazy-loaded, sondern aktiv initialisiert