<script setup>
  import { ref } from "vue";

  const name = ref("Davorin");

  const nancy = ref("Nancy Smith");

  function changeMe() {
    name.value += "+";
    // alert(name);
    // @ = v-o => događaj/events
    // : = v-bind => atributi
    // {{}} => content - sadržaj 
  }
</script>

<template>
    
  <header class="flex text-red-900">
    <h3>Our App</h3>
  </header>

  <main>
    <h1>Hello from Vue</h1>
    <div>{{ name }}</div>
    <button class="btn" v-o:click="changeMe">Change Me</button> 
    <img src="/public/nancy.jpg" v-bind:alt="nancy" :title="nancy" />
  </main>
</template>

