<template>

  <ul class="text-blue-900 font-bold flex justify-end">
    <li class="mx-2 hover:text-blue-500"><RouterLink :to="{ name: 'Home' }">Home</RouterLink></li>
    <li class="mx-2 hover:text-blue-500"><RouterLink :to="{ name: 'Billing' }">Billing</RouterLink></li>
  </ul>

  <div class="bg-gray-300 p-2">
    <RouterView></RouterView>
  </div>

</template>
