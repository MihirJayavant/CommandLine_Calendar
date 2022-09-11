using CommandLineCalender.Commands;

namespace CommandLineCalender;

public record class Context(CalendarManager Manager, IFeature[] Features, bool Exit = false);