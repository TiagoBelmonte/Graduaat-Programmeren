import React, { useEffect, useState } from "react";
import {
  View,
  FlatList,
  StyleSheet,
  ActivityIndicator,
  Text,
} from "react-native";
import { fetchTopNews } from "../api/news"; // (dia 143–144) Externe API aanroepen met fetch()
import NewsCard from "../components/NewsCard"; // (zelfgemaakt herbruikbaar component)
import MyText from "../components/MyText"; // (custom styled text component)

type Article = {
  title: string;
  description?: string;
  link: string;
};

export default function NewsScreen() {
  const [articles, setArticles] = useState<Article[]>([]);
  const [loading, setLoading] = useState(true); // (typisch loading pattern bij fetch)

  useEffect(() => {
    const load = async () => {
      try {
        const data = await fetchTopNews(); // (dia 143–144) Data ophalen via fetch()
        setArticles(data);
      } catch (error) {
        console.error("❌ Fout bij ophalen nieuws:", error); // (eenvoudige foutafhandeling)
      } finally {
        setLoading(false);
      }
    };

    load(); // (bij eerste render)
  }, []);

  return (
    <View style={styles.container}>
      {/* (dia 109) Container View */}
      <MyText style={styles.title}>📰 Topnieuws van vandaag</MyText>
      {/* (dia 110) Titel in Text component */}
      {loading ? (
        <ActivityIndicator size="large" color="#3b82f6" /> // (UX feedback bij laden)
      ) : (
        <FlatList
          data={articles}
          keyExtractor={(item) => item.link} // (unieke sleutel vereist voor FlatList)
          contentContainerStyle={{ paddingBottom: 40 }}
          renderItem={({ item }) => (
            <NewsCard
              title={item.title}
              description={
                item.description?.trim()
                  ? item.description
                  : "Geen beschrijving beschikbaar." // (fallback voor onvolledige API-data)
              }
              url={item.link}
            />
          )}
        />
      )}
    </View>
  );
}

const styles = StyleSheet.create({
  // (dia 115) Styling via StyleSheet object
  container: {
    flex: 1,
    backgroundColor: "#f0f4f8",
    paddingHorizontal: 20,
    paddingTop: 30,
  },
  title: {
    fontSize: 22,
    fontWeight: "bold",
    color: "#1e3a8a",
    marginTop: 20,
    marginBottom: 16,
    textAlign: "center",
  },
});
