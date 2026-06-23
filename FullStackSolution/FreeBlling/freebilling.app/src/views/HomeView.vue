<script setup>
  import { ref, reactive, computed, onMounted } from "vue";
  import { formatMoney } from "../formatters";
  import axios from "axios";
  import WaitCursor from "../components/WaitCursor.vue";
  import state from "../state";

  const name = ref("Davorin");

  const nancy = ref("Nancy Smith");

  const isBusy = ref(false);

  // const bills = reactive([
  //   // {
  //   //   "hoursWorked": 3.0,
  //   //   "rate": 250.00,
  //   //   "date": "2023-05-05",
  //   //   "work": "I did a thing...",
  //   //   "customerId": 1,
  //   //   "employeeId": 1
  //   // },
  //   // {
  //   //   "hoursWorked": 2.0,
  //   //   "rate": 150.00,
  //   //   "date": "2023-05-06",
  //   //   "work": "I did another thing...",
  //   //   "customerId": 1,
  //   //   "employeeId": 1
  //   // },
  //   // {
  //   //   "hoursWorked": 9.0,
  //   //   "rate": 250.00,
  //   //   "date": "2023-05-07",
  //   //   "work": "I finish a thing...",
  //   //   "customerId": 1,
  //   //   "employeeId": 1
  //   // },
  // ]);

  onMounted(async () => {
    if (state.timebills.length === 0) {
      try {
        isBusy.value = true;
        const result = await axios("/api/customers/1/timebills");
        if (result.status === 200) {
          state.timebills.splice(0, state.timebills.length, ...result.data);
        }
      } catch {
        console.log("Failed");
      } finally {
        setTimeout(() => isBusy.value = false, 3000);
      }
    }
  });

  const total = computed(() => {
    return state.timebills.map(b => b.billingRate * b.hours)
        .reduce((b, t) => t + b, 0);
  });

  function changeMe() {
    name.value += "+";
    // alert(name);
    // @ = v-on => događaj/events
    // : = v-bind => atributi
    // {{}} => content - sadržaj
  }

  function newItem() {
    state.timebills.push({
      customerId: 1,
      employeeId: 1,
      hoursWorked: 5.0,
      rate: 114,
      work: "More work",
      date: "2023-05-08"
    });

    console.log(state.timebills.length);
  }
</script>

<template>

  <header class="flex text-red-900">
    <h3>Our App</h3>
  </header>

  <main>
    <h1>Hello from Vue</h1>
    <WaitCursor :busy="isBusy" msg="Please wait..."></WaitCursor>
    <!--<div>{{ name }}</div>
    <button class="btn" v-o:click="changeMe">Change Me</button>
    <img src="/src/nancy.jpg" :alt="nancy" :title="nancy" />
    <button class="btn" @click="newItem">New Item</button>-->
    <table>
      <thead>
        <tr>
          <td>Hours</td>
          <td>Date</td>
          <td>Description</td>
        </tr>
      </thead>
      <tbody>
        <tr v-for="b in state.timebills">
          <td>{{b.hours}}</td>
          <td>{{b.date}}</td>
          <td>{{b.workPerformed}}</td>
        </tr>
      </tbody>
    </table>
    <div>Total: {{ formatMoney(total) }}</div>
  </main>
</template>

