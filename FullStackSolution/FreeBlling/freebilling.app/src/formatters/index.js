const formatter = Intl.NumberFormat("hr-HR", {
  style: "currency",
  currency: "EUR"
})

export function formatMoney(value) {
  if (typeof value === "number") {
    return formatter.format(value);
  }

  return value;
}

// format date
// format time
