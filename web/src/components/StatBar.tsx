interface StatBarProps {
  label: string;
  value: number;
  max?: number;
  color?: string;
}

export function StatBar({ label, value, max = 255, color }: StatBarProps) {
  const pct = Math.min(100, (value / max) * 100);

  const barColor =
    color ??
    (pct >= 67
      ? '#22c55e'
      : pct >= 33
        ? '#eab308'
        : '#ef4444');

  return (
    <div className="flex items-center gap-2 text-sm">
      <span className="w-24 shrink-0 text-right text-gray-500 font-medium">{label}</span>
      <span className="w-8 shrink-0 text-right font-semibold text-gray-800">{value}</span>
      <div className="flex-1 bg-gray-200 rounded-full h-2.5">
        <div
          className="h-2.5 rounded-full transition-all"
          style={{ width: `${pct}%`, backgroundColor: barColor }}
        />
      </div>
    </div>
  );
}
