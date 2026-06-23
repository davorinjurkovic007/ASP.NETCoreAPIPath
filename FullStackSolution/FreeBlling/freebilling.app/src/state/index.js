//state.js
import { reactive } from "vue";

export default reactive({
  token: "",
  customers: [],
  timebills: [],
  employees: [],
  currentCustomer: null
});
